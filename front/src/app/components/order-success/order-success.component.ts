import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { User } from 'src/app/models/User';
import { OrderService } from 'src/app/services/OrderService';

@Component({
  selector: 'app-order-success',
  templateUrl: './order-success.component.html',
  styleUrls: ['./order-success.component.scss']
})
export class OrderSuccessComponent implements OnInit {
  message: string;
  user: User;
  constructor(private orderService: OrderService, private cookieService: CookieService) { }

  ngOnInit(): void {
    let userCookie = this.cookieService.get("user");
    let user = new User();
    user.Password = JSON.parse(userCookie)["password"];
    user.Email = JSON.parse(userCookie)["email"];

    this.orderService.validateOrder(user).subscribe((response) => {
      console.log(response);
      this.message = response["success"];
    })
  }

}
