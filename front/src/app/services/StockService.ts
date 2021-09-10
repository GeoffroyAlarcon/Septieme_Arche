import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Customer } from "../models/Customer";
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { LineItemCart } from "../models/lineItemCart";
import { Cart } from "../models/cart";
@Injectable({
  providedIn: 'root',
})
export class StockService {
  private baseApi: string = "https://localhost:44368"
  constructor(private httpClient: HttpClient) {

  }

  public StockIsValid(cartLines: LineItemCart[], customer: Customer): Observable<any> {


    let params = new HttpParams();
    let cart = new Cart()
    const headers = new HttpHeaders()
      .set('content-type', 'application/json')
      .set('Access-Control-Allow-Origin', '*');
    cart.Customer = customer;
    cart.linesItemCart = cartLines;
    let customerJson = JSON.stringify(customer);
    console.log(customerJson);
    console.log(JSON.stringify(cartLines))
    return this.httpClient.post<any>(
      this.baseApi + "/api/stock/verifystock", { "customer": customer, "linesItemCart": cartLines }, { "headers": headers })
  }
}