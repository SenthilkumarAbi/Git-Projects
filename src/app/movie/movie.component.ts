import { Component, OnInit } from '@angular/core';
import { SharedService } from '../Shared/Shared.Service';
import { fn } from '@angular/compiler/src/output/output_ast';
@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.css']
})
export class MovieComponent implements OnInit {
  data: any;
  public txtInput: string='thor';
  constructor(private sharedservice: SharedService) { }
  
  ngOnInit() {
    // this.sharedservice.getMovie('thor').subscribe(res => {
    //   this.data = res;
    // });
  }

  public getData(){
      this.sharedservice.getMovie(this.txtInput.toString()).subscribe(res => {
      this.data = res;
    });

    // this.sharedservice.getMovie('thor').subscribe(res => {
    //   alert(this.txtInput);
    //   this.data = res;
    // });
  }

  

}
