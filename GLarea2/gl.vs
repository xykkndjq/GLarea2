attribute highp vec3 aPos;
attribute highp vec3 aNormal;
uniform highp mat4 model;
uniform highp mat4 inv_model;
uniform highp mat4 view;
uniform highp mat4 projection;
varying highp vec3 FragPos; 
varying highp vec3 Normal; 
void main(void)
{
		FragPos = vec3(model * vec4(aPos, 1.0));
		Normal = mat3(transpose(inverse(model))) * aNormal;
		gl_Position = projection * view * vec4(FragPos, 1.0);
}