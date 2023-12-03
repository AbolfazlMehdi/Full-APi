import {Component} from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(private http: HttpClient) {
    this.getFirstApi();
  }

  getFirstApi() {
    this.http.get("https://localhost:3000/api/WeatherForecast").subscribe({
      next: (res) => {
        debugger
      }
    })

  }
}
