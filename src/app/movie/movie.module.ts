import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WeatherComponent } from '../weather/weather.component';
import { FormsModule} from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
 
@NgModule({
  imports: [
    CommonModule, BrowserModule, FormsModule
  ],
  declarations: [WeatherComponent]
})
export class MovieModule { }
