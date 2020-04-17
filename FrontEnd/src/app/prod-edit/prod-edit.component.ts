import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProdService } from '../prod.service';

@Component({
  selector: 'app-prod-edit',
  templateUrl: './prod-edit.component.html',
  styleUrls: ['./prod-edit.component.css']
})
export class ProdEditComponent implements OnInit {
  angForm: FormGroup;
  member: any = {};

  constructor(private route: ActivatedRoute, private router: Router, private ms: ProdService, private fb: FormBuilder) {
    this.createForm();
  }

  createForm() {
    this.angForm = this.fb.group({
      name: ['', Validators.required],
      price: ['', Validators.required],
      lastupdated: ['', Validators.required],
      photo: ['', Validators.required]
    });
  }

  updateMember(name, price, lastupdated, photo) {
    this.route.params.subscribe(params => {
      this.ms.updateMember(name, price, lastupdated, photo, params.id);
      this.router.navigate(['members']);
    });
  }


  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.ms.editMember(params[`id`]).subscribe(res => {
        this.member = res;
      });
    });
  }
}
