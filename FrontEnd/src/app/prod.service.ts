import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProdService {

  //uri = 'http://localhost:20862/';
  uri2 = 'http://localhost:20862/';
  constructor(private http: HttpClient) { }

  addMember(name,price,lastupdated,photo) {
    const obj = {

      name ,
      price ,
      lastupdated ,
      photo

     
    };
    console.log(obj);
    this.http.post(`${this.uri2}/postNewProduct`, obj)
      .subscribe(res => console.log('Done'));
}

deleteMember(id) {
  return this
    .http
    .get(`${this.uri2}api/Delete/${id}`);
}


getMembers() {
  return this
    .http
    .get(`${this.uri2}/getAllProducts`); //--
}

editMember(id) {
  return this
          .http
          .get(`${this.uri2}/api/GetAllProductsById/${id}`);
  }

  updateMember(name, price, lastupdated, photo, id) {
    const obj = {
      name ,
      price ,
      lastupdated ,
      photo ,
      id

    };
    this
      .http
      .post(`${this.uri2}api/UpdateProduct/${id}`, obj)
      .subscribe(res => console.log('Done'));
  }

}