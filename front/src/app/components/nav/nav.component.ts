import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { BookService } from 'src/app/services/BookService';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {
  _sessionLength:number= sessionStorage.length
_searchForm: FormGroup
  constructor(private _formBuilder : FormBuilder, private _bookService:BookService, private _router:Router) { }
  ngOnInit(): void {
    this.initForm();
  }

  initForm(){
  this._searchForm =  this._formBuilder.group({
  search:""
  });
  }
  onSubmitForm(){
    const formValue = this._searchForm.value
  this._router.navigateByUrl('/booksbySearch/'+formValue["search"]);
}
   
  
}
