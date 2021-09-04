import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { StockService } from 'src/app/services/StockService';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.scss']
})
export class PaymentComponent implements OnInit {

  constructor(private router:Router,private stockService : StockService ) { }

  ngOnInit(): void {
  alert("votre paiement est en cours")
alert("votre paiement a été valider");
this.router.navigate(['orderSucess']);
  }
}
