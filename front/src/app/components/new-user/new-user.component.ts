import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Adress } from 'src/app/models/adress';
import { Customer } from 'src/app/models/Customer';
import { User } from 'src/app/models/User';
import { UserService } from 'src/app/services/UserService';

@Component({
  selector: 'app-new-user',
  templateUrl: './new-user.component.html',
  styleUrls: ['./new-user.component.scss']
})
export class NewUserComponent implements OnInit {

  constructor(private userService:UserService,private fb:FormBuilder) { }
  addUserForm:FormGroup;
customer:Customer= new Customer();

  ngOnInit(): void {
this.addUserForm =this.fb.group({
  email: ['', [Validators.required, Validators.email]],
   password: ['', Validators.required],
 firstName:['',Validators.required],
 lastName:['',Validators.required],
 birthDayDate:[Date,Validators.required]
})
  }
onSubmitForm(){
  this.customer.DeliveryAdress = new Adress();
let formValue = this.addUserForm.value;
this.customer.Email= formValue["email"];
this.customer.Password= formValue["password"];
this.customer.firstName= formValue["firstName"];
this.customer.lastName=formValue['lastName']
this.customer.BirthdayDate=formValue["birthDayDate"]
this.userService.addUser(this.customer).subscribe((response) => {
  alert(response);
  
})
}
}
