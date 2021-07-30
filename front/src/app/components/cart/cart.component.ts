import { Component, OnInit } from '@angular/core';
import { Item } from 'src/app/models/item';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {

public _items:Item[]
  constructor() { }

  ngOnInit(): void {
this.articlesCart()
  }

articlesCart(){
for( let x = 0; x<sessionStorage.length;x++){
let session= sessionStorage.getItem( sessionStorage.key(x) ||"");
this._items.push(JSON.parse(session ||""));
}
}
}
