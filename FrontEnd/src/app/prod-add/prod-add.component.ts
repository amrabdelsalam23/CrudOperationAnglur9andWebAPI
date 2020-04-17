import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ProdService } from '../prod.service';

@Component({
  selector: 'app-prod-add',
  templateUrl: './prod-add.component.html',
  styleUrls: ['./prod-add.component.css']
})
export class ProdAddComponent implements OnInit {
  angForm: FormGroup;
  constructor(private fb: FormBuilder, private ms: ProdService, private router: Router, ) {
    this.createForm();
  }
  
  createForm() {
    this.angForm = this.fb.group({
      
      name: ['', Validators.required],
      price: ['', Validators.required],
      lastupdated: ['', Validators.required],
      photo: ['', Validators.required],
    });
  }

  addMember(name, price,lastupdated, photo) {
    this.ms.addMember(name, price, lastupdated, photo);
    this.router.navigate(['members']);
  }

  ngOnInit(): void {
  }

}
