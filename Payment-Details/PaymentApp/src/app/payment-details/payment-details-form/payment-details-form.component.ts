import { Component } from '@angular/core';
import { PaymentDetaileService } from '../../sheard/payment-detaile.service';
import { NgForm } from '@angular/forms';
import { PaymentDetaile } from '../../sheard/payment-detaile.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-payment-details-form',
  templateUrl: './payment-details-form.component.html',
  styleUrl: './payment-details-form.component.css'
})
export class PaymentDetailsFormComponent {

    constructor(public paymentservice: PaymentDetaileService, private toastr: ToastrService ){}

    onSubmit(form: NgForm) {
    this.paymentservice.formSubmited = true;
    if(form.valid){
      if(this.paymentservice.formData.id == 0)
        this.insertRecord(form)
      else
      this.updateRecord(form)
    }
    
    }

    insertRecord(form: NgForm){
      this.paymentservice.postPaymentDetaile()
      .subscribe({
        next : res => {
          //reload page for shoing update
          this.paymentservice.list = res as PaymentDetaile[];
          //reset from after submit
          this.paymentservice.resetForm(form)
          this.toastr.success('Inserted Successfully...', 'Payment Detail');
        },
        error: err => {console.log(err)}
      })
    };
    updateRecord(form: NgForm){
      this.paymentservice.putPaymentDetaile()
      .subscribe({
        next : res => {
          //reload page for shoing update
          this.paymentservice.list = res as PaymentDetaile[];
          //reset from after submit
          this.paymentservice.resetForm(form)
          this.toastr.info('Updated Successfully...', 'Payment Detail');
        },
        error: err => {console.log(err)}
      })
    }
}
