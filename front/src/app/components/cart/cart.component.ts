import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { LineItemCart } from 'src/app/models/lineItemCart';
import { Customer } from 'src/app/models/Customer';
import { Item } from 'src/app/models/item';
import { StockService } from 'src/app/services/StockService';
import { NavComponent } from '../../share/nav/nav.component';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/UserService';
@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {
 _sessionLength= sessionStorage.length;;
  public _cart:LineItemCart[]= []
  
  constructor(private userService:UserService, private stockService:StockService,private cookieService: CookieService, private router:Router) { }

  ngOnInit(): void {
this.articlesCart()

  }

articlesCart(){
for( let x = 0; x<sessionStorage.length;x++){
let session= sessionStorage.getItem( sessionStorage.key(x) ||"");
let lineCart:LineItemCart=new LineItemCart();
lineCart.Amount = JSON.parse(session || "").Amount;
lineCart.item= JSON.parse(session || "").item;
  this._cart.push(lineCart);
console.log(lineCart.item);
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
cartlineJSON["Amount"] = inputValue;
console.log(cartlineJSON);
sessionStorage.setItem(inputId.toString(), JSON.stringify(cartlineJSON));
location.reload();
  }
  validateCart(){

    if (!this.userService.isAuthenticated()) {
      this.router.navigate(["auth"]);
    }
    let userCookie = this.cookieService.get("user");
    let customer = new Customer();
 customer.Password  =JSON.parse(userCookie)["password"];
                                                     customer.Email=JSON.parse(userCookie)["email"];
 customer.Id=JSON.parse(userCookie)["id"];
  this.stockService.StockIsValid(this._cart,customer).subscribe((message) =>{

    if(message["error"] != null ){
    alert(message["error"])
      return 
    }
    if(message["sucess"] != null){
  alert("Vous allez être redirigé(e) vers votre moyen de paiement ");
  this.router.navigate(["payment"]);
    }
    
      })
       }
  
  
}
