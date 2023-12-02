import { Component, OnInit } from '@angular/core';
import { PaymentDetaileService } from '../sheard/payment-detaile.service';

@Component({
  selector: 'app-payment-details',
  templateUrl: './payment-details.component.html',
  styleUrl: './payment-details.component.css'
})
export class PaymentDetailsComponent implements OnInit {

  constructor(public paymentservice: PaymentDetaileService ){}

  ngOnInit(): void {
    this.paymentservice.refreshList();
  }
}
