import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './share/nav/nav.component';
import { BooklistComponent } from './components/booklist/booklist.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BookService } from './services/BookService';
import { HttpClientModule } from '@angular/common/http';
import { SingleBookComponent } from './components/single-book/single-book.component';
import { HomePageComponent } from './components/home-page/home-page.component';
import { BookListSearchComponent } from './components/book-list-search/book-list-search.component';
import { CartComponent } from './components/cart/cart.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { AuthComponent } from './components/auth/auth.component';
import { NewUserComponent } from './components/new-user/new-user.component';
import { CookieService } from 'ngx-cookie-service';
import { CheckoutProcessComponent } from './components/checkout-process/checkout-process.component';
import { CartSummaryComponent } from './components/cart-summary/cart-summary.component';
import { FooterComponent } from './share/footer/footer.component';
import { PaymentComponent } from './components/payment/payment.component';
import { OrderSuccessComponent } from './components/order-success/order-success.component';
import { AllOrderComponent } from './components/all-order/all-order.component';
@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    BooklistComponent,
    SingleBookComponent,
    HomePageComponent,
    BookListSearchComponent,
    CartComponent,
    AuthComponent,
    NewUserComponent,
    CheckoutProcessComponent,
    CartSummaryComponent,
    FooterComponent,
    PaymentComponent,
    OrderSuccessComponent,
    AllOrderComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    FontAwesomeModule
  ],
  providers: [CookieService],
  bootstrap: [AppComponent]
})
export class AppModule { }
