import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './components/nav/nav.component';
import { BooklistComponent } from './components/booklist/booklist.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BookService } from './services/BookService';
import { HttpClientModule } from '@angular/common/http';
import { SingleBookComponent } from './components/single-book/single-book.component';
import { HomePageComponent } from './components/home-page/home-page.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    BooklistComponent,
    SingleBookComponent,
    HomePageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent, BookService]
})
export class AppModule { }
