import { Component } from '@angular/core';
import { HomePageComponent } from './libs/home/pages/home-page/home-page.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'mobile';
  initialPage = HomePageComponent
}
