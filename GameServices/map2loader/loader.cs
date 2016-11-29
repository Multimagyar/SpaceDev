namespace GameResources
{
	public class Materials
	{
		public List<Texture :: BaseTexture> textures = new List<Texture :: BaseTexture>;
		public Dictionary<string,Dictionary<string,string>> information = new Dictionary<string,Dictionary<string,string>>;
		
		public void texture_load(List<Texture :: BaseTexture>,Dictionary<string,string>);
		public void texture_delete(string);
		public void texture_destroy();
	}
	public class Models
	{
		public List<VertexBuffer :: Resource> textures = new List<VertexBuffer :: Resource>;
		public Dictionary<string,Dictionary<string,string>> information = new Dictionary<string,Dictionary<string,string>>;
		
		public void model_load(List<Texture :: BaseTexture>,Dictionary<string,string>,VertexFormats);
		public void model_delete(string);
		public void model_destroy();
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
		private Dictionary<string,string> current_class = new Dictionary<string,string>;
		private List<algebra::vec4> planes = new List<algebra::vec4>;
		private List<string> planes_Texture = new List<string>;
		private List<algebra::vec4> plane_axu = new List<algebra::vec4>;
		private List<algebra::vec4> plane_axv = new List<algebra::vec4>;
		private List<algebra::vec3> plane_scale = new List<algebra::vec3>;
		private List<algebra::vec3> collision_points = new List<algebra::vec3>;
		
		public void step(){}; //ez hajtja végre a betöltés lépéseit nem valódi párhuzamosítással
		
		public Dictionary<string,string> readclass(current_class){}; 																	//itt olvassuk be a jelenlegi class a szótárba
		public void ProcessPlaneData(List<algebra::vec4>,List<string>,List<algebra::vec4>,List<algebra::vec4>,List<algebra::vec3>){};	//a sík adatait olvassa
		public void ProcessInnerWavefront(){};						 																	//A vertex hálót olvassa
		public List<vec4> PlaneGetIntersections(current_class){};    																	//a pontokat amelyeket három sík metszete ad 
		public List<vec4> ShortestDistancePlane(List<vec4>){};       																	//megállapítja a legközelebbi pontot a origóhoz
		public bool ObjectExists(){};                                																	//ellenörzi hogy létezik-e ilyen objektum a resource tree-ben
		
	}
}

