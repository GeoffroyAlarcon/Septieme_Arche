import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './components/home-page/home-page.component';
import { SingleBookComponent } from './components/single-book/single-book.component';

const routes: Routes = [
  { path:"",component:HomePageComponent},
{path:"livre/:isbn",component:SingleBookComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
