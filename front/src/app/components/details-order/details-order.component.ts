import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { Customer } from 'src/app/models/Customer';
import { Item } from 'src/app/models/item';
import { LineItemOrder } from 'src/app/models/lineItemOrder';
import { Order } from 'src/app/models/order';
import { OrderService } from 'src/app/services/OrderService';

@Component({
  selector: 'app-details-order',
  templateUrl: './details-order.component.html',
  styleUrls: ['./details-order.component.scss']
})
export class DetailsOrderComponent implements OnInit {
_orderId :number;
_order:Order;
  constructor(private route: ActivatedRoute, private orderService:OrderService,private cookieService:CookieService) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe((value) => {
     this._orderId= parseInt( value.get("orderId")??"".toString());
     console.log(this._orderId);
  });
 this.getDetailOrder(); 
}
getDetailOrder(){
  let userCookie = this.cookieService.get("user");
  this._order = new Order();
this._order.id= this._orderId;
    this._order.customer = new Customer();
    this._order.customer.Password = JSON.parse(userCookie)["password"];
    this._order.customer.Email = JSON.parse(userCookie)["email"];
this.orderService.findOrderById(this._order).subscribe((result)=>{
this._order = result;
console.log(this._order)
});

}

disconnect(){
  this.cookieService.deleteAll();
      location.reload();
    }
}