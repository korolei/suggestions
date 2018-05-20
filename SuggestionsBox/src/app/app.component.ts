import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';
import { Validators, FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { Http, RequestOptions } from '@angular/http';
import { Subject } from 'rxjs/Subject';
import { debounceTime } from 'rxjs/operator/debounceTime';

import { NgbModal, ModalDismissReasons, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';

import { Suggestion } from './suggestion.class';
import { AppService } from './app.service';

@Component({
  selector: "app-root",
  templateUrl: './app.component.html',
  encapsulation: ViewEncapsulation.None,
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  suggestionData: Suggestion[] = [];
  isAdmin: boolean;
  showSuggestionBox: boolean;
  showReplyBox: boolean;
  userForm: FormGroup;
  moderatorForm: FormGroup;
  reply: string;
  closeResult: string;
  openedModal: NgbModalRef;

  private _error = new Subject<string>();
  private _success = new Subject<string>();
  staticAlertClosed = false;
  successMessage: string;
  errorMessage: string;

  constructor(
    private _appService: AppService,
    private _fb: FormBuilder,
      private modalService: NgbModal,
      private spinnerService: Ng4LoadingSpinnerService) { }

  ngOnInit(): void {

    this.getSuggestions();

    this._appService.getData('isadmin').subscribe(values => {
      this.isAdmin = values as boolean;
    });

    this.initForms();

    setTimeout(() => this.staticAlertClosed = true, 20000);
    this._success.subscribe((message) => this.successMessage = message);
    debounceTime.call(this._success, 10000).subscribe(() => this.successMessage = null);
    debounceTime.call(this._error, 20000).subscribe(() => this.errorMessage = null);
  }

    getSuggestions(): void  {
        this.spinnerService.show();
    this._appService.getData('').subscribe(res => {
      this.suggestionData = res as Suggestion[];
    },
    err => this.errorMessage = err,
    () => this.spinnerService.hide()
    );
  }

  openVerticallyCentered(content): void  {
    this.openedModal = this.modalService.open(content, { centered: true });
  }

  public initForms(): void  {
    this.userForm = this._fb.group({
      userPost: ['', Validators.required]
    });

    this.moderatorForm = this._fb.group({
      id: ['', Validators.required],
      moderatorReply: ['', Validators.required]
    });
  }

    public postSuggestion(form: FormGroup): void  {
        this.spinnerService.show();
      this._appService.postData('', form.value).subscribe(values => {
              if (values.success) {
                  this.showSuggestionBox = false;
                  form.reset();
                  this._success.next(values.message);
              } else {
                  this._error.next(values.message);
              }
      },
      err => this._error.next(err),
      () => this.spinnerService.hide()
      );
  }

  public putReply(form: FormGroup): void {
      this._appService.putData('', form.value).subscribe(values => {
              if (values.success) {
                  this.openedModal.close();
                  this.getSuggestions();
                  form.reset();
                  this._success.next(values.message);
              } else {
                  this._error.next(values.message);
              }
      },
      err => this._error.next(err),
      () => this.spinnerService.hide()
      );
  }

  public cancelUserPost(): void {
    this.showSuggestionBox = false;
    this.userForm.reset();
  }

  public updateForm(id: string): void  {
    this.moderatorForm.controls.id.setValue(id);
  }

}
