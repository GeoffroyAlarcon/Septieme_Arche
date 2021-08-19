import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { User } from 'src/app/models/User';
import { UserService } from 'src/app/services/UserService';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss']
})
export class AuthComponent implements OnInit {
  constructor(private fb: FormBuilder, private userService:UserService) {

   }
public authForm:FormGroup;

ngOnInit(): void {
  
this.authForm= this.fb.group({
  email: ['', [Validators.required, Validators.email]],
  password: ['', Validators.required],
})
}

  onSubmitForm(){
let token:any;
let user = new User(); 
let formValue = this.authForm.value;
this.userService.login(formValue["email"],formValue["password"]).subscribe((data)=>
{
  user = data["user"]
  token = data['token'];
  sessionStorage.setItem('token', JSON.stringify(token));
  sessionStorage.setItem('user', JSON.stringify(user));
})
  }
}
