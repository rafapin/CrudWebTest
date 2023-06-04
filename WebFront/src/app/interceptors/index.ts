import {HTTP_INTERCEPTORS} from "@angular/common/http";
import { SpinnerInterceptorService } from "./loader.interceptor";

export const INTERCEPTORS_PROVIDERS = [
    { provide: HTTP_INTERCEPTORS, useClass: SpinnerInterceptorService, multi: true },
];
