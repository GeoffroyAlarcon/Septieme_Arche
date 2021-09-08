import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthComponent } from './components/auth/auth.component';
import { BookListSearchComponent } from './components/book-list-search/book-list-search.component';
import { CartComponent } from './components/cart/cart.component';
import { HomePageComponent } from './components/home-page/home-page.component';
import { NewUserComponent } from './components/new-user/new-user.component';
import { OrderSuccessComponent } from './components/order-success/order-success.component';
import { PaymentComponent } from './components/payment/payment.component';
import { SingleBookComponent } from './components/single-book/single-book.component';
import { 
  AuthGuardService as AuthGuard 
} from './services/auth-guard.guard';

const routes: Routes = [
  { path:"",component:HomePageComponent},
{path:"book/:isbn",component:SingleBookComponent},
{path:"booksbySearch/:search", component:   BookListSearchComponent},
{path:"booksbySearch/:search/book/:isbn",component:SingleBookComponent}, // retourne une URL pour aller sur une page détail après une recherche
{path:"cart",component:CartComponent},
{path:"auth", component:AuthComponent},
{path:"addUser",component:NewUserComponent},
{path:"payment", canActivate: [AuthGuard],component:PaymentComponent },
{path:"orderSucess",canActivate:[AuthGuard],component:OrderSuccessComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
