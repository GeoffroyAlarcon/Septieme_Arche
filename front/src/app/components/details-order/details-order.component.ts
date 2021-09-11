import { Component, OnInit } from '@angular/core';
import { Item } from 'src/app/models/item';
import { LineItemOrder } from 'src/app/models/lineItemOrder';

@Component({
  selector: 'app-details-order',
  templateUrl: './details-order.component.html',
  styleUrls: ['./details-order.component.scss']
})
export class DetailsOrderComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }


articlesCart(arr:LineItemOrder[]) {
  for (let x = 0; x < sessionStorage.length; x++) {
    let session = sessionStorage.getItem(sessionStorage.key(x) || "");
    let lineCart: LineItemOrder = new LineItemOrder();
    lineCart.Amount = JSON.parse(session || "").Amount;
    lineCart.Item = JSON.parse(session || "").item;

  }
}
}