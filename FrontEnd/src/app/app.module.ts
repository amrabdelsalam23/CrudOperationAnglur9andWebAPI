import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { ProdService } from './prod.service';

import { AppComponent } from './app.component';
import { ProdAddComponent } from './prod-add/prod-add.component';
import { ProdGetComponent } from './prod-get/prod-get.component';
import { ProdEditComponent } from './prod-edit/prod-edit.component';

import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { MemberFilterPipe } from './prod-get/member-Filter.pipe';

@NgModule({
  declarations: [
    AppComponent,
    ProdAddComponent,
    ProdGetComponent,
    ProdEditComponent,
    MemberFilterPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    Ng2SearchPipeModule
  ],
  providers: [ProdService],
  bootstrap: [AppComponent]
})
export class AppModule { }
