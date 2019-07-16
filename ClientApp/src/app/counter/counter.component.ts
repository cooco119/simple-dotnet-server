import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
  public currentCount = 0;
  private httpClient: HttpClient;
  private url: string;
  
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.httpClient = http;
    this.url = baseUrl;
  }
  public incrementCounter() {
    this.currentCount++;
    this.httpClient.post(this.url + 'api/SampleData/WriteOnDatabase', this.currentCount).subscribe(result => {
      console.log(result);
    }, error => {
      console.error(error);
    });
  }
}
