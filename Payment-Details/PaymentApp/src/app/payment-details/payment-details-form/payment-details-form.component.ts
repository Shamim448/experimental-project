import { Component } from '@angular/core';
import { PaymentDetaileService } from '../../sheard/payment-detaile.service';
import { NgForm } from '@angular/forms';
import { PaymentDetaile } from '../../sheard/payment-detaile.model';

@Component({
  selector: 'app-payment-details-form',
  templateUrl: './payment-details-form.component.html',
  styleUrl: './payment-details-form.component.css'
})
export class PaymentDetailsFormComponent {

    constructor(public paymentservice: PaymentDetaileService ){}

    onSubmit(form: NgForm) {
    
      this.paymentservice.postPaymentDetaile()
      .subscribe({
        next : res => {
          this.paymentservice.list = res as PaymentDetaile[];
        },
        error: err => {console.log(err)}
      })
    
    }
}
