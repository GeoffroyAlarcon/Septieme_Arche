import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Item } from 'src/app/models/item';
import { LineItemOrder } from 'src/app/models/lineItemOrder';
import { OrderService } from 'src/app/services/OrderService';

@Component({
  selector: 'app-details-order',
  templateUrl: './details-order.component.html',
  styleUrls: ['./details-order.component.scss']
})
export class DetailsOrderComponent implements OnInit {
_orderId :number;
  constructor(private route: ActivatedRoute, private orderService:OrderService) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe((value) => {
     this._orderId= parseInt( value.get("orderId")??"".toString());
     console.log(this._orderId);
  });

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