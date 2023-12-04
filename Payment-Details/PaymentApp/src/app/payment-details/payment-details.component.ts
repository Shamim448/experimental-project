import { Component, OnInit } from '@angular/core';
import { PaymentDetaileService } from '../sheard/payment-detaile.service';
import { PaymentDetaile } from '../sheard/payment-detaile.model';
import { ToastrService } from 'ngx-toastr';
import { Console } from 'console';

@Component({
  selector: 'app-payment-details',
  templateUrl: './payment-details.component.html',
  styleUrl: './payment-details.component.css'
})
export class PaymentDetailsComponent implements OnInit {

  constructor(public paymentservice: PaymentDetaileService, private toastr: ToastrService ){}

  ngOnInit(): void {
    this.paymentservice.refreshList();
  }

  //Load record in form
  loadForm(selectedRecord: PaymentDetaile){
    //assign value not refarence
    this.paymentservice.formData = Object.assign({}, selectedRecord) ;
    
  }

  onDelete(id:number){
    if(confirm('Are you sure delete this record'))
    this.paymentservice.deletePaymentDetaile(id)
    .subscribe({
      next : res => {
        //reload page for shoing update
        this.paymentservice.list = res as PaymentDetaile[];
        
        this.toastr.error('Deleted Successfully...', 'Payment Detail');
      },
      error: err => {console.log(err)}
    })
    
  }
}
