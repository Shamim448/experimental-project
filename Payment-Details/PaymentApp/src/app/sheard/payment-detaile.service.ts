import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class PaymentDetaileService {

  constructor(private http:HttpClient) { }
 url:string = environment.appUrl;
  refreshList(){
    this.http.get(this.url + 'PaymentDetailes')
    .subscribe({
      next: rs =>{
        console.log(rs);
      },
      error: err => {
        console.log(err)
      }
    })
  }
}
