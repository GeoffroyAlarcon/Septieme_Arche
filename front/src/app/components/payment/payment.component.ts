import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.scss']
})
export class PaymentComponent implements OnInit {

  constructor(private router:Router) { }

  ngOnInit(): void {
  
alert("votre paiement a été valider")
this.router.navigate(['orderSucess']);
  }
}
