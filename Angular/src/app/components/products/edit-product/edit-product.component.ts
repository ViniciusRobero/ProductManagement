import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { HttpProviderService } from 'src/app/service/http-provider.service';


@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.scss']
})
export class EditProductComponent implements OnInit {
  EditProductForm: productForm = new productForm();

  @ViewChild("productForm")
  productForm!: NgForm;

  isSubmitted: boolean = false;
  productId: any;

  constructor(private toastr: ToastrService, private route: ActivatedRoute, private router: Router,
    private httpProvider: HttpProviderService) { }

  ngOnInit(): void {
    this.productId = this.route.snapshot.params['productId'];
    this.getCandidateDetailById();
  }

  getCandidateDetailById() {
    this.httpProvider.getProductDetailById(this.productId).subscribe((data: any) => {
      if (data != null && data.body != null) {
        var resultData = data.body.data;
        if (resultData) {
          this.EditProductForm.Id = resultData.id;
          this.EditProductForm.FirstName = resultData.firstName;
          this.EditProductForm.LastName = resultData.lastName;
          this.EditProductForm.Email = resultData.email;
          this.EditProductForm.Curriculum = resultData.curriculum;
        }
      }
    },
      (error: any) => { });
  }

  EditProduct(isValid: any) {
    this.isSubmitted = true;
    if (isValid) {
      this.httpProvider.saveProduct(this.EditProductForm).subscribe(async data => {
        if (data != null && data.body != null) {
          var resultData = data.body;
            if (resultData != null && resultData.succeeded) {
              this.toastr.success("Produto atualizado com sucesso.");
              setTimeout(() => {
                this.router.navigate(['/ListProducts']);
              }, 500);
            }
        }
      },
        async error => {
          this.toastr.error(error.message);
          setTimeout(() => {
            this.router.navigate(['/Home']);
          }, 500);
        });
    }
  }
}

export class productForm {
  Id: number = 0;
  FirstName: string = "";
  LastName: string = "";
  Email: string = "";
  Curriculum: string = "";
}
