import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookListSearchComponent } from './components/book-list-search/book-list-search.component';
import { HomePageComponent } from './components/home-page/home-page.component';
import { SingleBookComponent } from './components/single-book/single-book.component';

const routes: Routes = [
  { path:"",component:HomePageComponent},
{path:"book/:isbn",component:SingleBookComponent},
{path:"booksbySearch/:search", component:   BookListSearchComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
