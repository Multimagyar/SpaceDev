public:
//kamera jelenlegi koordinátái
double camera_position_x=0;
double camera_position_y=0;
double camera_position_z=0;
//A távolság, ahonnét már nem jelenítjük meg az objektumot
double zfar;
//0 ->2D mód, 1 ->3D mód
bool view=0;
private:
//up és forward vektor
double up_x=0;
double up_y=1;
double up_z=0;
double forward_x=0;
double forward_y=0;
double forward_z=-1;


//metódusok

//eltolás
private void translation(string axis,double mertek){
	/*
	double[] matrix=new double[4];
	for(int i=0;i<4;i++){
		matrix[i,i]=1;
	}
	
	if(axis == 'x'){matrix[0,3] =mertek;}
	else if(axis == 'y'){matrix[1,3] =mertek;}
	else matrix[2,3] =mertek;
	double temp_x=camera_position_x;
	double temp_y=camera_position_y;
	double temp_z=camera_position_z;
	
	camera_position_x=matrix[0,0]*temp_x+matrix[0,1]*temp_y+matrix[0,2]*temp_z+matrix[0,3];
	camera_position_y=matrix[1,0]*temp_x+matrix[1,1]*temp_y+matrix[1,2]*temp_z+matrix[1,3];
	camera_position_z=matrix[2,0]*temp_x+matrix[2,1]*temp_y+matrix[2,2]*temp_z+matrix[2,3];
	
	up_x=camera_position_x;
	up_y=camera_position_y+1;
	up_z=camera_position_z;
	
	forward_x=camera_position_x;
	forward_y=camera_position_y;
	forward_z=camera_position_z-1;
	
	*/
}
private void up(string axis, double angle){
	/*double[] matrix=new double[3];
	matrix=quat_rotation(up_x, up_y, up_z, angle, axis);
	up_x=matrix[0];
	up_y=matrix[0];
	up_z=matrix[0];*/
}
//a forward vektor kiszámítása rotációs mátrix-szal, a step metódus része lesz
private void forward(string axis){
	
	/*
	double[] matrix=new double[3];
	matrix=quat_rotation(forward_x, forward_y, forward_z, angle, axis);
	forward_x=matrix[0];
	forward_y=matrix[0];
	forward_z=matrix[0];
	*/
	
	/*
	(elvileg így az alábbi metódus feleslegessé válik)
	
	ha az x tengely irányába forgattunk
	double temp_y=forward_y;
	double temp_z=forward_z;
	forward_x=forward_x;
	forward_y=temp_y*cos(angle)+temp_z*(-sin(angle));
	forward_z=temp_y*sin(angle)+temp_z*cos(angle);*/
	
	/*ha az y tengely irányába forgattunk
	double temp_x=forward_x;
	double temp_z=forward_z;
	forward_x=temp_x*cos(angle)+temp_z*sin(angle);
	forward_y=forward_y;
	forward_z=temp_x*(-sin(angle)+temp_z*cos(angle));*/
	
	/*ha a z tengely irányába forgattunk
	double temp_x=forward_x;
	double temp_y=forward_y;
	forward_x=temp_x*cos(angle)+temp_y*(-sin(angle));
	forward_y=temp_x*sin(angle)+temp_y*cos(angle);
	forward_z=forward_z;*/
}
/*x      |  1  0       0       0 | |x|
		 |  0  cos(A) -sin(A)  0 | |y|
         |  0  sin(A)  cos(A)  0 | |z|
         |  0  0       0       1 | |0|
		 
y		 |  cos(A)  0   sin(A)  0 | |x|
		 |  0       1   0       0 | |y|
         | -sin(A)  0   cos(A)  0 | |z|
         |  0       0   0       1 | |0|
		 
z		 |  cos(A)  -sin(A)   0   0 | |x|
		 |  sin(A)   cos(A)   0   0 | |y|
         |  0        0        1   0 | |z|
         |  0        0        0   1 | |0|
*/
// left vektor kiszámítása az up és forward segítségével, a step metódus része lesz 
private void left()
{
	/*double left_x=up_y*forward_z-up_z*forward_y;
	double left_y=-(up_x*forward_z-up_z*forward_x);
	double left_z=up_x*forward_y-up_y*forward_x;*/
} 
//forgató metódus
private double[] quat_rotation(double x, double y, double z, double angle, string axis){
	/*
	
	double n_x=0;
	double n_y=0;
	double n_z=0;
	
	if(axis == 'x'){n_x =1;}
	else if(axis == 'y'){n_y =1;}
	else n_z=1;
	double[]q1=new double[4];
	double q1[0]=cos(szog/2);
	double q1[1]=sin(szog/2)*n_x;
	double q1[2]=sin(szog/2)*n_y;
	double q1[3]=sin(szog/2)*n_z;
	
	double[]q2=new double[4];
	double q2[0]=cos(szog/2);
	double q2[1]=-sin(szog/2)*n_x;
	double q2[2]=-sin(szog/2)*n_y;
	double q2[3]=-sin(szog/2)*n_z;
	
	double[,]quaternion = new double[4,4];
	
	quaternion[0,0]=q1[0];
	quaternion[0,1]=-q1[1];
	quaternion[0,2]=-q1[2];
	quaternion[0,3]=-q1[3];
	quaternion[1,0]=q1[1];
	quaternion[1,1]=q1[0];
	quaternion[1,2]=-q1[3];
	quaternion[1,3]=q1[2];
	quaternion[2,0]=q1[2];
	quaternion[2,1]=q1[3];
	quaternion[2,2]=q1[0];
	quaternion[2,3]=-q1[1];
	quaternion[0,0]=q1[3];
	quaternion[0,0]=-q1[2];
	quaternion[0,0]=q1[1];
	quaternion[0,0]=q1[0];
	
	double[]v=new double[4];
	double v[0]=0;
	double v[1]=x;
	double v[2]=y;
	double v[3]=z;
	double[] vuj=new double[4];
	
	for(int i=0;i<4;i++){
		double vuj[i]=v[0]*quaternion[i,0]+v[1]*quaternion[i,1]+v[2]*quaternion[i,2]+v[3]*quaternion[i,3];
	}
	
	quaternion[0,0]=vuj[0];
	quaternion[0,1]=-vuj[1];
	quaternion[0,2]=-vuj[2];
	quaternion[0,3]=-vuj[3];
	quaternion[1,0]=vuj[1];
	quaternion[1,1]=vuj[0];
	quaternion[1,2]=-vuj[3];
	quaternion[1,3]=vuj[2];
	quaternion[2,0]=vuj[2];
	quaternion[2,1]=vuj[3];
	quaternion[2,2]=vuj[0];
	quaternion[2,3]=-vuj[1];
	quaternion[0,0]=vuj[3];
	quaternion[0,0]=-vuj[2];
	quaternion[0,0]=vuj[1];
	quaternion[0,0]=vuj[0];
	
	double[]eredmeny=new double[3];
	double check=q2[0]*quaternion[0,0]+q2[1]*quaternion[0,1]+q2[2]*quaternion[0,2]+q2[3]*quaternion[0,3];
	eredmeny[0]=q2[0]*quaternion[1,0]+q2[1]*quaternion[1,1]+q2[2]*quaternion[1,2]+q2[3]*quaternion[1,3];
	eredmeny[1]=q2[0]*quaternion[2,0]+q2[1]*quaternion[2,1]+q2[2]*quaternion[2,2]+q2[3]*quaternion[2,3];
	eredmeny[2]=q2[0]*quaternion[3,0]+q2[1]*quaternion[3,1]+q2[2]*quaternion[3,2]+q2[3]*quaternion[3,3];

	if(check!=0)break;
	else return eredmeny;
	
	*/
}
//a fő számoló metódus
public void step()//TODO:A metódus megírása
//public void draw();

//https://msdn.microsoft.com/en-us/library/system.windows.media.media3d(v=vs.110).aspx