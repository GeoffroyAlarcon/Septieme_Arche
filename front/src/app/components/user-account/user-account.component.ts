import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-user-account',
  templateUrl: './user-account.component.html',
  styleUrls: ['./user-account.component.scss']
})
export class UserAccountComponent implements OnInit {

  constructor(private cookieService:CookieService) { }

  ngOnInit(): void {
  }

  disconnect(){
this.cookieService.deleteAll();
    location.reload();
  }

}
