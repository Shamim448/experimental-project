import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { PaymentDetaile } from './payment-detaile.model';

@Injectable({
  providedIn: 'root'
})
export class PaymentDetaileService {

  constructor(private http:HttpClient) { }

 url:string = environment.appUrl;
  list:PaymentDetaile[] = []

  refreshList(){
    this.http.get(this.url + 'PaymentDetailes')
    .subscribe({
      next: rs =>{
        this.list = rs as PaymentDetaile[]
      },
      error: err => {
        console.log(err)
      }
    })
  }
}
