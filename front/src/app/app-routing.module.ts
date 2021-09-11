import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AllOrderComponent } from './components/all-order/all-order.component';
import { AuthByMarketingComponent } from './components/auth-by-marketing/auth-by-marketing.component';
import { AuthComponent } from './components/auth/auth.component';
import { BookListSearchComponent } from './components/book-list-search/book-list-search.component';
import { CartComponent } from './components/cart/cart.component';
import { DashboardReportingComponent } from './components/dashboard-reporting/dashboard-reporting.component';
import { HomePageComponent } from './components/home-page/home-page.component';
import { NewUserComponent } from './components/new-user/new-user.component';
import { OrderSuccessComponent } from './components/order-success/order-success.component';
import { PaymentComponent } from './components/payment/payment.component';
import { SingleBookComponent } from './components/single-book/single-book.component';
import { UserAccountComponent } from './components/user-account/user-account.component';
import {
  AuthGuardService as AuthGuard
} from './services/auth-guard.guard';

const routes: Routes = [
  { path: "", component: HomePageComponent },
  { path: "book/:isbn", component: SingleBookComponent },
  { path: "booksbySearch/:search", component: BookListSearchComponent },
  { path: "booksbySearch/:search/book/:isbn", component: SingleBookComponent }, // retourne une URL pour aller sur une page détail après une recherche
  { path: "cart", component: CartComponent },
  { path: "auth", component: AuthComponent },
  { path: "authbyMarketing", component: AuthByMarketingComponent },
  { path: "addUser", component: NewUserComponent },
  { path: "payment", canActivate: [AuthGuard], component: PaymentComponent },
  { path: "orderSuccess", canActivate: [AuthGuard], component: OrderSuccessComponent },
  { path: "allOrder", canActivate: [AuthGuard], component: AllOrderComponent },
  { path: "dashBoardReporting", canActivate: [AuthGuard], component: DashboardReportingComponent },
 { path:"useraccount", canActivate: [AuthGuard],component:UserAccountComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
