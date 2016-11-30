namespace GameResources
{
	public class Materials
	{
		public List<Texture.BaseTexture> textures = new List<Texture.BaseTexture>;
		public Dictionary<string,Dictionary<string,string>> information = new Dictionary<string,Dictionary<string,string>>;
		
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
		public List<Resource.VertexBuffer> textures = new List<Resource.VertexBuffer>;
		public Dictionary<string,Dictionary<string,string>> information = new Dictionary<string,Dictionary<string,string>>;
		
		public void model_load(List<Texture.BaseTexture>,Dictionary<string,string>,VertexFormats);
		public void model_delete(string);
		public void model_destroy();
	}
}
namespace ObjParser
{
	public class Obj
	{
		public List<Vertex> VertexList;
		public List<Face> FaceList;
		public List<TextureVertex> TextureList;
		private string data[];
		
		public Obj()
	    {
            VertexList = new List<Vertex>();
            FaceList = new List<Face>();
			TextureList = new List<TextureVertex>();
		}
		public void LoadWavefrontData(string path){}
		private void ProcessData(string line){}
		public Resource.VertexBuffer ModelToBuffer(VertexFormats){};

	}
}
namespace algebra
{
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
		private int depth;
		private string filename;
		private Dictionary<string,string> current_class;
		private List<algebra.vec4> planes;
		private List<string> planes_Texture;
		private List<algebra.vec4> plane_axu;
		private List<algebra.vec4> plane_axv;
		private List<algebra.vec3> plane_scale;
		private List<algebra.vec3> collision_points;
		
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

