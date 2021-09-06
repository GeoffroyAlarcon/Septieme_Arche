import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Book } from 'src/app/models/book';
import { DigitalBook } from 'src/app/models/bookDigital';
import { LineItemCart } from 'src/app/models/lineItemCart';
import { BookService } from 'src/app/services/BookService';
@Component({
  selector: 'app-single-book',
  templateUrl: './single-book.component.html',
  styleUrls: ['./single-book.component.scss']
})
export class SingleBookComponent implements OnInit {
   _isbn: string;
  _isDigitalbook:boolean = false;
_book:Book;
_cartLine:LineItemCart = new LineItemCart();
_replaceValue:string;
_addCartForm:FormGroup;
  constructor(private route:ActivatedRoute,private _bookService: BookService,private formBuilder: FormBuilder, private router: Router ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((value) => {
    this._isbn= value.get("isbn")??"".toString();

    });
    this.initForm();
    this.getDetailBook();
  }

  getDetailBook(){
  this._bookService.getBookByISBN(this._isbn).subscribe((res) => {
    if(res["isDigital"] == true){
    this._book= new DigitalBook();
    this._isDigitalbook = true;
    }
  this._book= res;
  this._book.image="../../../assets/img/"+this._book.image;
  
this._replaceValue = this._book.priceExcludingTax.toString().replace(".",",");
  });

}
initForm(){
this._addCartForm=  this.formBuilder.group({
amount:0
  });
}
onSubmitForm(){
  const formValue = this._addCartForm.value
this._cartLine.Amount=formValue["amount"]; 
this._cartLine.item= this._book;
 this.addArticle(this._cartLine);
 }
addArticle(cartLine:LineItemCart){
  if(sessionStorage.getItem(cartLine.item.id.toString()) != null){
    alert("vous avez déjà ajouté cet article à votre panier "); return 
  }
  if(this._cartLine.Amount == 0 ){
    alert(" veuillez saisir une quantité supérieure à 0 ");
  return 
  }
  else
  sessionStorage.setItem(cartLine.item.id.toString(), JSON.stringify(cartLine));
  location.reload();

}
}


