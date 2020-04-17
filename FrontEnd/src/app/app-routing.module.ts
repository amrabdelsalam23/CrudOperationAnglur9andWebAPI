import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProdAddComponent } from './prod-add/prod-add.component';
import { ProdEditComponent } from './prod-edit/prod-edit.component';
import { ProdGetComponent } from './prod-get/prod-get.component';


const routes: Routes = [
  {
    path: 'prod/create',
    component: ProdAddComponent
  },
  {
    path: 'edit/:id',
    component: ProdEditComponent
  },
  {
    path: 'prods',
    component: ProdGetComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
