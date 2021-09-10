import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
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

  constructor(private userService: UserService, private fb: FormBuilder, private router: Router) { }
  addUserForm: FormGroup;
  customer: Customer = new Customer();

  ngOnInit(): void {
    this.addUserForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      birthDayDate: [Date, Validators.required],
      country: ['france', Validators.required],
      zipCode: ['', Validators.required],
      street: ['', Validators.required],
      streetNumber: ['', Validators.required],
      typeBuilding: ['', Validators.required],
      digitalCodeNumber: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      city: ['', Validators.required]
    })
  }
  onSubmitForm() {
    this.customer.DeliveryAdress = new Adress();
    let formValue = this.addUserForm.value;
    this.customer.Email = formValue["email"];
    this.customer.Password = formValue["password"];
    this.customer.FirstName = formValue["firstName"];
    this.customer.LastName = formValue['lastName'];
    this.customer.BirthdayDate = formValue["birthDayDate"];
    this.customer.DeliveryAdress.country = formValue["country"];
    this.customer.DeliveryAdress.digitalCodeNumber = formValue["digitalCodeNumber"];
    this.customer.DeliveryAdress.phoneNumber = formValue["phoneNumber"];
    this.customer.DeliveryAdress.street = formValue["street"];
    this.customer.DeliveryAdress.streetNumber = formValue["streetNumber"];
    this.customer.DeliveryAdress.typeBuilding = formValue["typeBuilding"];
    this.customer.DeliveryAdress.zipCode = formValue["zipCode"];
    this.customer.DeliveryAdress.city = formValue["city"];
    this.userService.addUser(this.customer).subscribe((response) => {
      alert("vous avez bien été ajouté, veuillez maintenant vous connecter avec votre nouvelle identifiant");
      this.router.navigate(["auth"]);
    })
  }
}
