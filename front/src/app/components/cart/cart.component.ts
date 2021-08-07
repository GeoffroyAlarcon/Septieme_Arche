import { Component, OnInit } from '@angular/core';
import { CartLine } from 'src/app/models/cartline';
import { Item } from 'src/app/models/item';
import { NavComponent } from '../nav/nav.component';
@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {

  public _cart:CartLine[]= []
  
  constructor() { }

  ngOnInit(): void {
this.articlesCart()
  }

articlesCart(){
for( let x = 0; x<sessionStorage.length;x++){
let session= sessionStorage.getItem( sessionStorage.key(x) ||"");
let lineCart:CartLine=new CartLine();
lineCart.amount = JSON.parse(session || "")._amount;
lineCart.item= JSON.parse(session || "")._item;
  this._cart.push(lineCart);

}
}
deleteItemStorage(index:number){
sessionStorage.removeItem(sessionStorage.key(index) || "");
location.reload();

}
}
