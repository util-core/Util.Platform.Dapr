//����WebӦ�ó���������
var builder = WebApplication.CreateBuilder( args );

//���ý���������
builder.Services.AddHealthChecksUI()
    .AddInMemoryStorage();

//������־
builder.Logging.AddJsonConsole();

//����WebӦ�ó���
var app = builder.Build();

//���û�·��
var pathBase = builder.Configuration["PathBase"];
if ( string.IsNullOrEmpty( pathBase ) == false ) 
    app.UsePathBase( pathBase );

//���ý������UI
app.UseHealthChecksUI( config => {
    config.ResourcesPath = string.IsNullOrEmpty( pathBase )
        ? "/ui/resources"
        : $"{pathBase}/ui/resources";
} );
app.MapGet( string.IsNullOrEmpty( pathBase ) ? "/" : pathBase, () => Results.LocalRedirect( "~/healthchecks-ui" ) );
app.MapHealthChecksUI();

//����Ӧ��
app.Run();