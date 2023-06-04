import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpEvent, HttpHandler, HttpRequest } from '@angular/common/http';
import { finalize, Observable } from 'rxjs';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable()
export class SpinnerInterceptorService implements HttpInterceptor {
    constructor( private spinnerService: NgxSpinnerService) {}
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        this.spinnerService.show().then();
        return next.handle(req).pipe(
            finalize(() => this.spinnerService.hide().then()),
        );
    }
}
