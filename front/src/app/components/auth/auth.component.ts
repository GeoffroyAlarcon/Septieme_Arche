import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { User } from 'src/app/models/User';
import { UserService } from 'src/app/services/UserService';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss']
})
export class AuthComponent implements OnInit {
  constructor(private fb: FormBuilder, private userService:UserService,private router:Router,private cookieService:CookieService) {

   }
public authForm:FormGroup;

ngOnInit(): void {
  this.UserConnect();
this.authForm= this.fb.group({
  email: ['', [Validators.required, Validators.email]],
  password: ['', Validators.required],
})
}

UserConnect(){
  if (this.userService.isAuthenticated()) {
    this.router.navigate([""]);
  }
}

  onSubmitForm(){
let token:any;
let user = new User(); 
let formValue = this.authForm.value;
this.userService.login(formValue["email"],formValue["password"]).subscribe((data)=>
{
  if(data == null){
  alert("aucun compte n'est trouvé à cette association de mot de passe et d'email");
  return
  }
 else{
  alert("vous avez bien été identifié ! ");
 
  user = data["user"]
  token = data['token'];
  this.cookieService.set('token', token);
  this.cookieService.set('user', JSON.stringify(user));
  location.reload();
}
})
  }
}
