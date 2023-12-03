import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { PaymentDetaile } from './payment-detaile.model';

@Injectable({
  providedIn: 'root'
})
export class PaymentDetaileService {

  constructor(private http:HttpClient) { }

  url:string = environment.appUrl + 'PaymentDetailes';
  list:PaymentDetaile[] = [];
  formData : PaymentDetaile = new PaymentDetaile();

  refreshList(){
    this.http.get(this.url)
    .subscribe({
      next: rs =>{
        this.list = rs as PaymentDetaile[]
      },
      error: err => {
        console.log(err)
      }
    })
  }

  //post value 
  postPaymentDetaile(){
   return this.http.post(this.url, this.formData)
  }
}
