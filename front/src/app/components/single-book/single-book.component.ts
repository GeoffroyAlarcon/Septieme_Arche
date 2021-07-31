import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Book } from 'src/app/models/book';
import { CartLine } from 'src/app/models/cartline';
import { BookService } from 'src/app/services/BookService';
@Component({
  selector: 'app-single-book',
  templateUrl: './single-book.component.html',
  styleUrls: ['./single-book.component.scss']
})
export class SingleBookComponent implements OnInit {
   _isbn: string;
_book:Book;
_cartLine:CartLine = new CartLine();
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
  this._book= res;
  
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
this._cartLine.amount=formValue["amount"]; 
this._cartLine.item= this._book;
 this.addArticle(this._cartLine);
 }
addArticle(cartLine:CartLine){
  if(sessionStorage.getItem(cartLine.item.id.toString()) != null){
    alert("vous avez déjà ajouté cet article à votre panier ");
  return 
  }
  else
  sessionStorage.setItem(cartLine.item.id.toString(), JSON.stringify(cartLine));
}
}


