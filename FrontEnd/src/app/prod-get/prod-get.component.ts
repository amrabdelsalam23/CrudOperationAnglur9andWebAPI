import { Component, OnInit, Input, Output,EventEmitter } from '@angular/core';
import Member from '../Prod';
import { ProdService } from '../prod.service';
import {ProddownloadService} from '../prod.downloadService';


import { HttpEventType } from '@angular/common/http';


@Component({
  selector: 'app-prod-get',
  templateUrl: './prod-get.component.html',
  styleUrls: ['./prod-get.component.css']
})



export class ProdGetComponent implements OnInit {

  @Input() public disabled: boolean;
  @Input() public fileName: string;

  members: Member[];
  searchTerm: string;
  constructor(private ms: ProdService , private msa: ProddownloadService) {  }
  //constructor(private msa: ProddownloadService){}
 
  deleteMember(id, index) {
    this.ms.deleteMember(id).subscribe(res => {
      this.members.splice(index, 1);
    });
}


public download() {
    
  this.msa.downloadFile(this.fileName).subscribe(
    data => {
      switch (data.type) {
        case HttpEventType.DownloadProgress:
          
          break;
        case HttpEventType.Response:
          
          const downloadedFile = new Blob([data.body], { type: data.body.type });
          const a = document.createElement('a');
          a.setAttribute('style', 'display:none;');
          document.body.appendChild(a);
          a.download = this.fileName;
          a.href = URL.createObjectURL(downloadedFile);
          a.target = '_blank';
          a.click();
          document.body.removeChild(a);
          break;
      }
    },
    
  );
}



  ngOnInit() {
    this.ms
      .getMembers()
      .subscribe((data: Member[]) => {
        this.members = data;
      });
  }
}