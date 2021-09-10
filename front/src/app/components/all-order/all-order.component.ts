import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { User } from 'src/app/models/User';
import { OrderService } from 'src/app/services/OrderService';

@Component({
  selector: 'app-all-order',
  templateUrl: './all-order.component.html',
  styleUrls: ['./all-order.component.scss']
})
export class AllOrderComponent implements OnInit {

  constructor(private cookieService: CookieService, private orderService:OrderService) { }

  ngOnInit(): void {
    this.getAllOrder();
  }

  getAllOrder() {
    let userCookie = this.cookieService.get("user");
    let user = new User();
    user.Password = JSON.parse(userCookie)["password"];
    user.Email = JSON.parse(userCookie)["email"];
this.orderService.findAllOrder(user).subscribe((result)=>{
  console.log(result);
})
  }
}
