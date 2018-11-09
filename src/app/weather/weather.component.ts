import { Component, OnInit } from '@angular/core';
import {SharedService } from '../Shared//Shared.Service'

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.css']
})
export class WeatherComponent implements OnInit {
  data:any;
  public txtWeather: string='TamilNadu';

  constructor(private sharedservie: SharedService) { 

  }

  ngOnInit() {
    // this.sharedservie.getWeather(this.txtWeather.toString()).subscribe(res=>
    //   {
    //     this.data = res;
    //   });
 
  }

  public GetWeatherInfo(){
    this.sharedservie.getWeather(this.txtWeather.toString()).subscribe(res=>
      {
        this.data = res;
      });
  }
}
