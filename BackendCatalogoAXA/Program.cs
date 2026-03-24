using BackendCatalogoAXA.Middleware;

// Other existing code...

if (app.Environment.IsDevelopment())
{
    // Development specific configurations...
}
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
// Remaining existing code...