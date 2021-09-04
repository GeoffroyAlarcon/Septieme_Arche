import { Component, OnInit } from '@angular/core';
import { CartLine } from 'src/app/models/cartline';
import { Item } from 'src/app/models/item';
import { NavComponent } from '../../share/nav/nav.component';
@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {
 _sessionLength= sessionStorage.length;;
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
updateAmount(inputId:number, event:any){
 var inputValue:number = event.target.value;
  let cartlineJSON:any
 cartlineJSON = JSON.parse( sessionStorage.getItem(inputId.toString()) || "");
cartlineJSON["_amount"] = inputValue;
console.log(cartlineJSON);
sessionStorage.setItem(inputId.toString(), JSON.stringify(cartlineJSON));
location.reload();
  }
  
}
