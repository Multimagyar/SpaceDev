namespace GameResources
{
	public class Materials
	{
		public List<Texture.BaseTexture> textures;
		public Dictionary<string,Dictionary<string,string>> information;
		
		public Materials()
		{
			textures = new List<Texture.BaseTexture>;
			information = new Dictionary<string,Dictionary<string,string>>;
		}
		
		public void texture_load(List<Texture.BaseTexture>,Dictionary<string,string>);
		public void texture_delete(string);
		public void texture_destroy();
	}
	public class Models
	{
		public List<Resource.VertexBuffer> model;
		public Dictionary<string,Dictionary<string,string>> information;
		
		public Materials()
		{
			model = new List<Resource.VertexBuffer>;
			information = new Dictionary<string,Dictionary<string,string>>;
		}
		
		public void model_load(List<Texture.BaseTexture>,Dictionary<string,string>,Resource.VertexFormats);
		public void model_delete(string);
		public void model_destroy();
	}
}

namespace ObjParser  //Wavefront file betöltésére
{
	public class Obj
	{
		//vertex adatok
		public List<algebra.vec3> VertexList;
		public List<algebra.vec3> NormalList;
		public List<algebra.vec2> TextureList;
		public List<algebra.vec3> FaceList;
		//beolvasott adatsor
		private string data[];
		//default construktor
		public Obj()
	    {
            VertexList = new List<algebra.vec3>();
            FaceList = new List<algebra.vec3>();
            NormalList = new List<algebra.vec3>();
			TextureList = new List<algebra.vec2>();
		}
		//adat feldogozó funkciók
		public void LoadWavefrontData(string path){}
		private void ProcessData(string line){}
		public Resource.VertexBuffer ModelToBuffer(VertexFormats){};

	}
}

namespace algebra
{
	//Algebrai adat típusok pálya és model betöltéshez.
	public class vec2
	{
		public double x;
		public double y;
		
		public double dot_product(vec2){};
		public vec2 cross_product(vec2){};
		public void normalize(){};
	}
	public class vec3:vec2
	{
		public double z;
		
		public double dot_product(vec3){};
		public vec3 cross_product(vec3){};
		public void normalize(){};
	}
	public class vec4:vec3
	{
		public double w;
		
		public double dot_product(vec4){};
		public vec4 cross_product(vec4){};
		public void normalize(){};
	}
}

namespace Map2loader
{
	public class Datastorage
	{
		private int depth; //zárójel mélység
		private string filename; //fájlt neve
		private Dictionary<string,string> current_class; //a classban élvő betöltött adatok
		private List<algebra.vec4> planes;   //végtelen síkok normálja és távolsága az origótól
		private List<string> planes_Texture;  //a textúrák neve
		private List<algebra.vec4> plane_axu;  //u szerinti textúra forgatás
		private List<algebra.vec4> plane_axv;  //v szerinti textúra forgatás
		private List<algebra.vec3> plane_scale;   //textúra nyújtás
		private List<algebra.vec3> collision_points;    //sík ütközések pontja
		
		//default construktor
		public Datastorage()
		{
			int depth=0;
			string filename="";
			current_class = new Dictionary<string,string>;
			planes = new List<algebra.vec4>;
			planes_Texture = new List<string>;
			plane_axu = new List<algebra.vec4>;
			plane_axv = new List<algebra.vec4>;
			plane_scale = new List<algebra.vec3>;
			collision_points = new List<algebra.vec3>;
		}
		
		public void step(){}; //ez hajtja végre a betöltés lépéseit nem valódi párhuzamosítással
		
		public Dictionary<string,string> readclass(Dictionary<string,string>){}; 																	//itt olvassuk be a jelenlegi class a szótárba
		public void ProcessPlaneData(List<algebra.vec4>,List<string>,List<algebra.vec4>,List<algebra.vec4>,List<algebra.vec3>){};	//a sík adatait olvassa
		public void ProcessInnerWavefront(){};						 																	//A vertex hálót olvassa
		public List<algebra.vec4> PlaneGetIntersections(List<algebra.vec4>){};    																	//a pontokat amelyeket három sík metszete ad 
		public List<algebra.vec4> ShortestDistancePlane(List<algebra.vec4>){};       																	//megállapítja a legközelebbi pontot a origóhoz
		public bool ObjectExists(){};                                																	//ellenörzi hogy létezik-e ilyen objektum a resource tree-ben
		
	}
}

