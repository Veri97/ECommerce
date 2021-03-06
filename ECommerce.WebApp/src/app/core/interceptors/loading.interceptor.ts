import {Injectable} from "@angular/core";
import {HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from "@angular/common/http";
import {Observable} from "rxjs";
import {LoadingService} from "../services/loading.service";
import {delay, finalize} from "rxjs/operators";

@Injectable()
export class LoadingInterceptor implements HttpInterceptor {

  constructor(private loadingService: LoadingService) {
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    this.loadingService.busy();

    return next.handle(req).pipe(
      //delay(1000),
      finalize(() => {
        this.loadingService.idle();
      })
    );
  }

}
