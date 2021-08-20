import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { User } from 'src/app/models/User';
import { BookService } from 'src/app/services/BookService';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {
  _sessionLength:number= sessionStorage.length;
_searchForm: FormGroup;
_user:any ;

  constructor(private _formBuilder : FormBuilder, private _bookService:BookService, private _router:Router, private cookieService:CookieService) { }
  ngOnInit(): void {
    this.initForm();
    let userCookie = this.cookieService.get("user");
   
   if(userCookie.length != 0){
    this._user= new User();
this._user=     JSON.parse(userCookie);

  } 
  else {
    this._user=null
  }
 }

  initForm(){
  this._searchForm =  this._formBuilder.group({
  search:""
  });
  }
  onSubmitForm(){
    const formValue = this._searchForm.value
  this._router.navigateByUrl('/booksbySearch/'+formValue["search"]);
}
   
  
}
